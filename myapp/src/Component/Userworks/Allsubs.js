import {React,useRef,useState,useEffect} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import JWT from "jwt-decode";
export default function Subjecthome(){
    const navigate=useNavigate();
    const [Subjects,storedd]=useState([]);
    const [userid,setuserid]=useState();
    var decoded=JWT(localStorage.getItem('usertoken'));
    

        useEffect(() => {
            fetchOptions(); // Fetch options when the component mounts
          }, []);
          const fetchOptions=async()=>
          {
                const d=await fetch(`https://localhost:7062/api/Exam/GetSubsbybid?bid=${decoded.BranchId}`);
                const data = await d.json();
                console.log(d);
                console.log(data);
                storedd(data);
    
        //     }catch(error)
        //     {
        //         alert('Something went wrong!! Please retry later');
        //     }
          }
          function ques(id)
          {
            localStorage.setItem("subid",id);
            navigate('/exampage');
          }
          return(
            <>
            <h1>All Subjects</h1>
<table class="table">
  <thead class="thead-dark">
    <tr>
      
      <th scope="col">Name</th>
      <th scope='col'>Actions</th>
      {/* <th scope="col">Deny</th> */}
    </tr>
  </thead>
  <tbody>
  {Subjects.map((option) => (
    <tr>
      <td>{option.name}</td>
      <td type="button" class="btn btn-danger" onClick={() => ques(option.id)}>Appear for this paper</td>
    </tr>
  ))}
  </tbody>
    </table>

            </>
          )
        }