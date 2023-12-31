import {React,useRef,useState,useEffect} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate,createSearchParams } from 'react-router-dom';
import axios from 'axios';
import Modifyinstitute from './Modifyinstitute';
export default function Subjecthome(){
    const navigate=useNavigate();
    const [Subjects,storedd]=useState([]);
    const [userid,setuserid]=useState();
        useEffect(() => {
            fetchOptions(); // Fetch options when the component mounts
          }, []);
          const fetchOptions=async()=>
          {
                const d=await fetch('https://localhost:7062/api/Institute/GetAll');
                const data = await d.json();
                console.log(d);
                console.log(d.data);
                storedd(data);
    
        //     }catch(error)
        //     {
        //         alert('Something went wrong!! Please retry later');
        //     }
          }
    function addsubs()
    {
        navigate('/addinstitute');
    }
    const deleted=async(e)=>
    {
        try{
        const d= await axios.delete(`https://localhost:7062/api/Subject/DeleteSubject?id=${e}`);
        alert("Deleted Successfully");
        }catch(error)
        {
            alert("Something went!!");
        }

    }
    function modify(e)
    {
        navigate({
            pathname:'/modifyinstitute',
            search:createSearchParams({
            id:e
            }).toString()
        });

    }
    return(<>
    <div >
    <Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#ApprovalPending" onClick={addsubs}>Add Institute</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
 <h1>All Institutes</h1>
<table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Id</th>
      <th scope="col">Name</th>
      <th scope="col">Address</th>
      <th scope="col">City</th>
      <th scope="col">Region</th>
      <th scope="col">Postal Code</th>
      <th scope="col">Phone no.</th>
      <th scope='col'>Actions</th>
      {/* <th scope="col">Deny</th> */}
    </tr>
  </thead>
  <tbody>
  {Subjects.map((option) => (
    <tr>
      <th scope="row">{option.id}</th>
      <td>{option.name}</td>
      <td>{option.address}</td>
      <td>{option.city}</td>
      <td>{option.region}</td>
      <td>{option.postalCode}</td>
      <td>{option.phone}</td>
      <td type="button" class="btn btn-danger" onClick={() => deleted(option.id)} >Delete</td>
      <br/>
      <td type="button" class="btn btn-success" onClick={() => modify(option.id)}>Edit</td>
    </tr>
  ))}
  </tbody>
    </table>
    </>);
}