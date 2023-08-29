
import { useNavigate } from 'react-router-dom';
import '../../App.css';
import { react,useRef } from "react";
import axios from 'axios';
export default function(){
    const navigate=useNavigate();
    const ema=useRef();
    const sub=async()=>
    {
       const d= await axios.put(`https://localhost:7062/api/User/UserAgainRequest?ema=${ema}`);
       alert("submitted");
       navigate('/userlogin');
    }
    const subrej=async()=>
    {
      navigate('/userlogin'); 
    }
return(
    <>
        <div class="centered">
  <h1>Your Request Had Been Rejected</h1>
  </div>
  <div>
  <h2>Give your Email id for Requesting again</h2>
  <input type="text" ref={ema} />
</div>
<button class="btn btn-success" onClick={sub}>Request Again?</button>
<button class="btn btn-danger" onClick={subrej}>Cancel</button>

    </>
)
}