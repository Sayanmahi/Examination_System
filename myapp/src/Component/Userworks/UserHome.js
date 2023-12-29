import {React,useRef} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
export default function Userlogin(){
    const navigate=useNavigate();
    function seesub()
    {
        navigate('/allsubs');
    }
    function result()
    {
        navigate('/results');
    }
    return(<>
    <div >
    <Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#seesubs" onClick={seesub}>See Subjects</Nav.Link>
<Nav.Link href="#Results" onClick={result}>Results</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
    </>);
}