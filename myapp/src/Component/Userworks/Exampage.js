import {React,useRef,useState,useEffect} from 'react';
import {useLocation} from 'react-router-dom';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import JWT from "jwt-decode";
import DisplayItem from './DisplayItem'
export default function Exampage(){
  const pp=useRef();
    const gg=localStorage.getItem('subid');
    const [Subjects,storedd]=useState([]);
    const pqref=useRef();
    const [val,setval]=useState();
    const navigate=useNavigate();
    var decoded=JWT(localStorage.getItem('usertoken')); 


    useEffect(() => {
        fetchOptions(); // Fetch options when the component mounts
      }, []);
      const fetchOptions=async()=>
      {
            const d=await fetch(`https://localhost:7062/api/Exam/GetQuestionswrtsub/${gg}`);
            const data = await d.json();
            console.log(d);
            console.log(data);
            storedd(data);

    //     }catch(error)
    //     {
    //         alert('Something went wrong!! Please retry later');
    //     }
      }
      const qq=Subjects.map(m=>
        <DisplayItem
        id={m.id}
        title={m.title}
        option1={m.option1}
        option2={m.option2}
        option3={m.option3}
        option4={m.option4}
        subid={gg}
        uid={decoded.UserId}
        />);
      const submit = async() => {
       var d= await axios.post(`https://localhost:7062/api/Exam/Submit?uid=${decoded.UserId}&subid=${gg}`);
       window.alert("Completed the Exam");
       navigate('/results');
      };
      // const handleChange1= async(t) =>
      // {
      //   const d={
      //     UserId:decoded.UserId,
      //     SubId:gg,
      //     QuesId:t,
      //     Option:val
      //   };
      //   console.log(d);
      // }
    return(
        <>
        <h2>Choose a option for each each question</h2>
{/* <table class="table">
  <thead class="thead-dark">
    <tr>
      
      <th scope="col"></th>
      <th scope="col">Deny</th> */}
    {/* </tr>
  </thead> */}
  {/* <tbody>
  {Subjects.map((option) => (
    <tr>
      <td><b>{option.title}</b>
      <br />
      <br />
      1. {option.option1}
      <br />
      2. {option.option2}
      <br />
      3. {option.option3}
      <br />
      4. {option.option4}
      <br />
      <label>Choose our option: </label>
      <span></span>
      <input ref={pp}></input>
      <button className='btn btn-success' onClick={()=>handleChange1(option.id,pp)}>Save</button> */}
  {/* </td>
    </tr> */}
  {/* ))}
  </tbody>
    </table> */}
    {qq}
    <button className='btn btn-success' onClick={submit}>SUBMIT</button>
        </>
    )
}