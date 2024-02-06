import {React,useRef,useState,useEffect} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
export default function Branchhome(){
    const navigate=useNavigate();
    const [Subjects,storedd]=useState([]);
    const [userid,setuserid]=useState();
    const ss= localStorage.getItem("admintoken");
        useEffect(() => {
            fetchOptions(); // Fetch options when the component mounts
          }, []);
          const fetchOptions=async()=>
          {
                const d=await fetch('https://localhost:7062/api/Branch/GetallBranches');
                const data = await d.json();
                console.log(d);
                console.log(data);
                storedd(data);
    
        //     }catch(error)
        //     {
        //         alert('Something went wrong!! Please retry later');
        //     }
          }
    function addsubs()
    {
        navigate('/addsubjects');
    }
    const deleted=async(e)=>
    {
        console.log("eeeeeeeeeeee   "+e);
        try{
        const d= await axios.delete(`https://localhost:7062/api/Branch/DeleteBranch?id=${e}`,{
          headers:{
            'Authorization': `Bearer ${ss}`
        }
        });
        alert("Deleted Successfully");
        window.location.reload();
        }catch(error)
        {
            alert("Something went!!");
        }

    }
    const addbranch=async()=>
    {
      navigate("/addbranch");
    }
    const ee=async()=>
    {
      navigate('/addsubjectconnection');
    }
    return(<>
    <div >
    <Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#ApprovalPending" onClick={addsubs}>Add Subjects</Nav.Link>
<Nav.Link href="#Subjects" onClick={ee}>Add Subject Connection</Nav.Link>
<Nav.Link href="#AddBranch" onClick={addbranch}>Add Branch</Nav.Link>
<Nav.Link href="#Institute" >Institute</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
 <h1>All Subjects</h1>
<table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Id</th>
      <th scope="col">Name</th>
      <th scope='col'>Actions</th>
      {/* <th scope="col">Deny</th> */}
    </tr>
  </thead>
  <tbody>
  {Subjects.map((option) => (
    <tr>
      <th scope="row">{option.id}</th>
      <td>{option.name}</td>
      <td type="button" class="btn btn-danger" onClick={() => deleted(option.id)} >Delete</td>
    </tr>
  ))}
  </tbody>
    </table>
    </>);
}