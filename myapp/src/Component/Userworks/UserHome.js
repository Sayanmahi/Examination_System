import {React,useRef} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
export default function Userlogin(){
    return(<>
    <div >
    <Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#Register" >Register as a student</Nav.Link>
<Nav.Link href="#Userlogin" >User Login</Nav.Link>
<Nav.Link href="#Adminlogin">Admin Login</Nav.Link>
<Nav.Link href="#Teacherlogin" >Teacher Login</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
    </>);
}