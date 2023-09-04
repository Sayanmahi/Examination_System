import {React,useRef} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
export default function Adminhome(){
    const navigate=useNavigate();
    function userapp()
    {
        navigate('/userapproval');
    }
    function subhome()
    {
        navigate('/subjecthome');
    }
    function branhome()
    {
        navigate('/branchhome');
    }
    function insthome()
    {
        navigate('/institutehome');
    }
    return(<>
    <div >
    <Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#ApprovalPending" onClick={userapp}>Approvals Pending</Nav.Link>
<Nav.Link href="#Subjects" onClick={subhome}>Subjects</Nav.Link>
<Nav.Link href="#Branch" onClick={branhome}>Branch</Nav.Link>
<Nav.Link href="#Institute" onClick={insthome}>Institute</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
    </>);
}