import {React,useRef, useState,useEffect} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
import JWT from "jwt-decode";
export default function Results(){
    const [Marks,markstate]=useState([]);
    const navigate=useNavigate();
    var decoded=JWT(localStorage.getItem('usertoken'));

    useEffect(() => {
    
        fetchOptions(); // Fetch options when the component mounts
        
        // catch(e)
        // {
        //     window.alert("No results found.Please appear for a papaer!");
        //     console.log(Marks);
        //     navigate('/userhome');
        // }
      }, []);
      const fetchOptions= async()=>
      {
        const d=await fetch(`https://localhost:7062/api/Exam/GetResult?uid=${decoded.UserId}`);
        const data = await d.json();
        console.log(data);
        markstate(data);
      }
      return(
        <>
        <h1>Results of the Subjects appeared</h1>
        <table class="table">
  <thead class="thead-dark">
    <tr>
      
      <th scope="col">Subject Name</th>
      <th scope='col'>Total Marks</th>
      <th scope='col'>Marks Got</th>
      <th scope='col'>Percentage</th>
      <th scope='col'>Status</th>
      {/* <th scope="col">Deny</th> */}
    </tr>
  </thead>
  <tbody>
  {Marks.map((option) => (
    <tr>
      <td>{option.subjectName}</td>
      <td>{option.totalMarks}</td>
      <td>{option.marksGot}</td>
      <td>{option.subjectPercentage}</td>
      <td>{option.status}</td>

    </tr>
  ))}
  </tbody>
    </table>

        </>
      )
}