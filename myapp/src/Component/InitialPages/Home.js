import React from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import NavbarCollapse from 'react-bootstrap/esm/NavbarCollapse';
import {Routes, Route, useNavigate} from 'react-router-dom';


export default function Home() {
    const navigate=useNavigate();
    function userlogin()
    {
        console.log("eeeeeeeeeeeeeee")
        navigate("/userlogin");
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
<Nav.Link href="#Register" onClick={studreg}>Register as a student</Nav.Link>
<Nav.Link href="#Userlogin" onClick={userlogin}>User Login</Nav.Link>
<Nav.Link href="#Adminlogin" onClick={adminlog}>Admin Login</Nav.Link>
<Nav.Link href="#Teacherlogin" onClick={teacherlogins}>Teacher Login</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
        </>
    );
}