import {React,useRef,useState,useEffect} from 'react';
import axios from 'axios';
import {
  MDBBtn,
  MDBContainer,
  MDBCard,
  MDBCardBody,
  MDBCardImage,
  MDBRow,
  MDBCol,
  MDBIcon,
  MDBInput
}
from 'mdb-react-ui-kit';
import '../../App.css'
import "bootstrap/dist/css/bootstrap.min.css";
import { useNavigate } from 'react-router-dom';
export default function()
{
  const navigate=useNavigate();
    const nameref=useRef('');
    const phoneref=useRef('');
    const emailref=useRef('');
    const passwordref=useRef('');
    const [institutes, setInstitutes] = useState([]);
    const [selectedinstitute, setSelectedinstitute] = useState(null);
    const [branches, setBranches] = useState([]);
    const [selectedbranch, setSelectedbranch] = useState(null);
    useEffect(() => {
        fetchOptions(); // Fetch options when the component mounts
      }, []);

      const fetchOptions = async () => {
        try {
          const response = await fetch(
            "https://localhost:7062/api/Institute/GetAll"
          ); // Replace with your API endpoint
          const data = await response.json();
          setInstitutes(data); // Set the received data as options
        } catch (error) {
          console.error("Error fetching options:", error);
        }
      };
      useEffect(() => {
        fetchOptions1(); // Fetch options when the component mounts
      }, []);

      const fetchOptions1 = async () => {
        try {
          const response = await fetch(
            "https://localhost:7062/api/Branch/GetAllBranches"
          ); // Replace with your API endpoint
          const data = await response.json();
          setBranches(data); // Set the received data as options
        } catch (error) {
          console.error("Error fetching options:", error);
        }
      };
    const sub=async()=>
    {
        // console.log("Institute " + selectedinstitute);
        // console.log("Branch "+selectedbranch);
        const data={
          Name:nameref.current.value,
          Email:emailref.current.value,
          Password:passwordref.current.value,
          Phone:phoneref.current.value,
          InstId:selectedinstitute,
          BranchId:selectedbranch

        };
        console.log(data);
        try{
          const d= axios.post('https://localhost:7062/api/User/Register',data);
          alert("Registered Successfully");
          navigate('/userlogin');
          console.log(d);
        }catch{
          console.log("something went wrong");
        }
    }
    return(
        <MDBContainer className="my-5">

        <MDBCard>
          <MDBRow className='g-0'>
            <MDBCol md='6'>
              <MDBCardImage src='https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/img1.webp' alt="login form" className='rounded-start w-100'/>
            </MDBCol>
  
            <MDBCol md='6'>
              <MDBCardBody className='d-flex flex-column'>
                {/* to have an image withinMDBCardimage tag paste src in the below section */}
                {/* <div className='d-flex flex-row mt-2'>
                  <MDBIcon fas icon="cubes fa-3x me-3"  style={{ color: '#ff6219' }}/>
                </div> */}
  
                <h5 className="fw-normal my-4 pb-3" style={{letterSpacing: '1px'}}>Student Register</h5>
                <MDBInput wrapperClass='mb-4' label='Name' id='formControlLg' type='text' size="lg" ref={nameref}/>
                <MDBInput wrapperClass='mb-4' label='Phone Number' id='formControlLg' type='text' size="lg" ref={phoneref}/>


                  <MDBInput wrapperClass='mb-4' label='Email address' id='formControlLg' type='email' size="lg" ref={emailref}/>
                  <div className="container">
                  <select className="my-select" onChange={(e)=>{
                  console.log("institute "+e.target.value);
                  setSelectedinstitute(e.target.value);
                 
                  }
                  }>
              <option value="">Select an Institute</option>
              {institutes && institutes.map((option) => (
                <option key={option.id} value={option.id}>
                  {option.name}
                </option>
              ))}
            </select>
            </div>
            <div className="container">
                  <select className="my-select" onChange={(e)=>{
                  console.log("branch "+e.target.value);
                  setSelectedbranch(e.target.value);
                 
                  }
                  }>
              <option value="">Select the Branch</option>
              {branches && branches.map((option) => (
                <option key={option.id} value={option.id}>
                  {option.name}
                </option>
              ))}
            </select>
            </div>
                  <MDBInput wrapperClass='mb-4' label='Password' id='formControlLg' type='password' size="lg" ref={passwordref}/>
  
                <MDBBtn className="mb-4 px-5" color='dark' size='lg' onClick={sub}>Login</MDBBtn>
                <a className="small text-muted" href="#!">Forgot password?</a>
                <p className="mb-5 pb-lg-2" style={{color: '#393f81'}}>Don't have an account? <a href="#!" style={{color: '#393f81'}}>Register here</a></p>
  
                <div className='d-flex flex-row justify-content-start'>
                  <a href="#!" className="small text-muted me-1">Terms of use.</a>
                  <a href="#!" className="small text-muted">Privacy policy</a>
                </div>
  
              </MDBCardBody>
            </MDBCol>
  
          </MDBRow>
        </MDBCard>
  
      </MDBContainer>
    );
}