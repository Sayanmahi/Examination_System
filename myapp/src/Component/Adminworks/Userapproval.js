import {React,useRef,useState,useEffect} from 'react';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';
import '../../App.css';
export default function(){
  const navigate=useNavigate();
const [Names,storedd]=useState([]);
const [userid,setuserid]=useState();
const abc1=localStorage.getItem('admintoken');
    useEffect(() => {
        fetchOptions(); // Fetch options when the component mounts
      }, []);
      const fetchOptions=async()=>
      {
        console.log(abc1);
        try{
            const d=await axios.get(`https://localhost:7062/api/User/UserAskingapproval`,{
              headers:{
                'Authorization': `Bearer ${abc1}`
            }
            });
            console.log(d);
            storedd(d.data);
        }
        catch(e)
        {
            alert("you are not an Admin!");
            navigate("/");
        }

    //     }catch(error)
    //     {
    //         alert('Something went wrong!! Please retry later');
    //     }
      }
      const approved=async(e)=>
      {
        try{
        const d= await axios.put(`https://localhost:7062/api/User/AdminApprove?id=${e}`,{
          headers:{
            'Authorization': `Bearer ${abc1}`
          }
        });
        window.location.reload();
        }catch(e)
        {
          alert('Unauthorised access');
          navigate('/');
        }
      }
      const Deny=async(e)=>
      {
        try{
        const d= await axios.put(`https://localhost:7062/api/User/AdminDeny?id=${e}`,{
          headers:{
            'Authorization': `Bearer ${abc1}`
          }
        });
        window.location.reload();
        }catch(e)
        {
          alert('Unauthorised access');
          navigate('/');
        }
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
  