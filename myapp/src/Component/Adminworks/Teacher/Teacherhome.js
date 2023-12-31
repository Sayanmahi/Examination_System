
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import NavbarCollapse from 'react-bootstrap/esm/NavbarCollapse';
import {Routes, Route, useNavigate} from 'react-router-dom';
import {React,useRef,useState,useEffect} from 'react';


export default function Teacherhome() {
    const navigate=useNavigate();
    useEffect(() => {
        fetchfunction();
    },[]);
    const fetchfunction=async()=>
    {
        
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
    function teacherlogins()
    {
        navigate("/teacherlogin");
    }
    return(
        <>
            <div>
<Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#MySubjects" onClick={studreg}>My Subjects</Nav.Link>
<Nav.Link href="#Add/Modify" onClick={userlogin}>Add/Modify Questions</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
        </>
    );
}