import {React,useRef,useState,useEffect} from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import '../../App.css';
export default function(){
  const navigate=useNavigate();
const [Names,storedd]=useState([]);
const [userid,setuserid]=useState();
    useEffect(() => {
        fetchOptions(); // Fetch options when the component mounts
      }, []);
      const fetchOptions=async()=>
      {
            const d=await fetch('https://localhost:7062/api/User/UserAskingapproval');
            const data = await d.json();
            console.log(d);
            console.log(data);
            storedd(data);

    //     }catch(error)
    //     {
    //         alert('Something went wrong!! Please retry later');
    //     }
      }
      const approved=async(e)=>
      {
        const d= await axios.put(`https://localhost:7062/api/User/AdminApprove?id=${e}`);
        window.location.reload();
      }
      const Deny=async(e)=>
      {
        const d= await axios.put(`https://localhost:7062/api/User/AdminDeny?id=${e}`);
        window.location.reload();
      }
      return(
        <>
        <div class="centered">
  <h1>User Approval Section</h1>
</div>
<table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">User Id</th>
      <th scope="col">Name</th>
      <th scope="col">Institute Name</th>
      <th scope="col">Branch</th>
      <th scope="col">Actions</th>
      {/* <th scope="col">Deny</th> */}
    </tr>
  </thead>
  <tbody>
  {Names.map((option) => (
    <tr>
      <th scope="row">{option.id}</th>
      <td>{option.name}</td>
      <td>{option.institute}</td>
      <td>{option.branch}</td>
      <td type="button" class="btn btn-success" onClick={() => approved(option.id)} >Approve</td>
      <span></span>
      <td type="button" class="btn btn-danger" onClick={()=> Deny(option.id)}>Deny</td>
    </tr>
  ))}

    </tbody>
    </table>
    </>
      );
    }
  