import {React,useRef,useState,useEffect} from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';
export default function Addbranchconnection(){
    const navigate=useNavigate();
    const [Subjects,storedd]=useState([]);
    const [branches,setbranches]=useState([]);
    const [Bran,setselectedbranches]=useState([]);
    const [b,bb]=useState([]);
    const[bname,bbname]=useState();
    const[ac,acp]=useState();
    const[a,ap]=useState();

    useEffect(() => {
        fetchBranches(); // Fetch options when the component mounts
      }, []);
      const fetchBranches = async () => {
        try {
          const response = await fetch(
            "https://localhost:7062/api/Subject/GetSubjects"
          ); // Replace with your API endpoint
          const data = await response.json();
          bb(data); // Set the received data as options
        } catch (error) {
          console.error("Error fetching options:", error);
        }
        console.log("Bbbbbbbbbbbbbbbbbb "+b);
      };
        useEffect(() => {
            fetchOptions(); // Fetch options when the component mounts
          }, []);
          const fetchOptions=async()=>
          {
                const d=await fetch('https://localhost:7062/api/Branch/GetAllBranches');
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
    const Addbran=async(e,y)=>
    {
        bbname(y);
        ap(e);
        try{
        const d= await fetch(`https://localhost:7062/api/Branch/GetSubbyBranch?id=${e}`);
        const data= await d.json();
        setbranches(data);

        }catch(error)
        {
            alert("Something went!!");
        }

    }
    const addbranch=async()=>
    {
      navigate("/addbranch");
    }
    const adde=async()=>
    {
        console.log("SID "+ac);
        console.log("BID "+a)
        try{
            const d=await axios.post(`https://localhost:7062/api/Branch/AddSubjecttoBranch/${ac}/${a}`);
            alert("Connection established");
            navigate('/addsubjectconnection');

        }catch(error)
        {
            alert("Something went wrong");
        }
    }
    const del=async(z,x)=>
    {
      try
      {
        const v=await axios.delete(`https://localhost:7062/api/Branch/Delete/${z}/${x}`);
        alert("Branch Connection deleted");
        navigate('/addsubjectconnection');
      }catch{
         alert("Something went wrong");
      }
    }
    return(<>
    <div >
    <Navbar bg="dark" variant="dark">
<Container>
<Navbar.Brand href="#Home" >Exam Portal</Navbar.Brand>
<Nav className="ms-auto">
{/* <Nav.Link href="#Menu" onClick={mm}>Menu</Nav.Link>  */}
<Nav.Link href="#ApprovalPending" onClick={addsubs}>Add Subjects</Nav.Link>
<Nav.Link href="#AddBranch" onClick={addbranch}>Add Branch</Nav.Link>
{/* <Nav.Link href="#Adminlogin" onClick={adl}>Admin Login</Nav.Link> */}



</Nav> 
</Container>
</Navbar>
{/* <div className="CoverImg"></div> */}
</div>
 <h1>All Branches</h1>
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
      <td type="button" class="btn btn-success" onClick={() => Addbran(option.id,option.name)} >Add Subject</td>
    </tr>
  ))}
  </tbody>
    </table>


    <h1>Branch:-{bname}</h1>
<table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Id</th>
      <th scope="col">Name</th>
      <th scope="col">Action</th>
      {/* <th scope="col">Deny</th> */}
    </tr>
  </thead>
  <tbody>
  {branches.map((option) => (
    <tr>
      <th scope="row">{option.id}</th>
      <td>{option.name}</td>
      <button className='btn btn-danger' onClick={()=>del(option.id,a)}>Delete</button>
    </tr>
  ))}
  </tbody>
    </table>

    <div className="container">
          <select className="my-select" isMulti onChange={(e)=>{
          console.log("branches "+e.target.value);
          acp(e.target.value);
         
          }
          }>
      <option value="">Select an option</option>
      {b && b.map((option) => (
        <option key={option.id} value={option.id}>
          {option.name}
        </option>
      ))}
    </select>
    </div>
    <button className='btn btn-success' onClick={adde}>Add</button>

    </>);
}