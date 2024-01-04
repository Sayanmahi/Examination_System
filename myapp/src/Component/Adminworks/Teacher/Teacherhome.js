
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import axios from 'axios';
import NavbarCollapse from 'react-bootstrap/esm/NavbarCollapse';
import {Routes, Route, useNavigate,createSearchParams} from 'react-router-dom';
import {React,useRef,useState,useEffect} from 'react';
import JWT from "jwt-decode";

export default function Teacherhome() {
    const navigate=useNavigate();
    var decoded=JWT(localStorage.getItem('teachertoken'));
    const[sub,substate]=useState([]);
    console.log(decoded);
    useEffect(() => {
        fetchfunction();
    },[]);
    const fetchfunction=async()=>
    {
        const d=await axios.get(`https://localhost:7062/api/Institute/GetMySubjectsByTeacherId?id=${decoded.UserId}`);
        substate(d.data);
        console.log(d);
        console.log("stateabc",sub);
    }

    function userlogin()
    {
        navigate("/addmodify");
    }
    function adminlog()
    {
        navigate("/adminlogin");
    }
    function studreg()
    {
        navigate("/register");
    }
    function modify(e)
    {
        navigate({
            pathname:'/addmodify',
            search:createSearchParams({
            id:e
            }).toString()
        });
    }

    return(
        <>
            <div>
<Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
{/* <Nav.Link href="#MySubjects" onClick={studreg}>My Subjects</Nav.Link>
<Nav.Link href="#Add/Modify" onClick={userlogin}>Add/Modify Questions</Nav.Link> */}
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
<h1><b>My Subjects</b></h1>
<table class="table">
    <thead class="thead-dark">
        <tr>
            <th class="col">Subject Name</th>
            <th class="col">Get Questions</th>
        </tr>
    </thead>
    <tbody>
    {sub.map((option) => (
    <tr>
      <td>{option.name}</td>
      <td><button class="btn btn-danger" onClick={()=> modify(option.id)}>Get</button></td>
    </tr>
    ))}
    </tbody>
</table>
        </>
    );
}