import {React,useRef} from 'react';
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
import axios from 'axios'
import { useNavigate } from 'react-router-dom';
export default function Teacherlogin(){
  const navigate=useNavigate();
    const emailref=useRef('');
    const passwordref=useRef('');
    const sub=async()=>
    {
        const data={
            Email:emailref.current.value,
            Password:passwordref.current.value,
        };
        try{
          const d=await axios.post('https://localhost:7062/api/User/TeacherLogin',data);
          if(d.data=="You are not authorized to enter this page")
          {
            alert(d.data);
          }
          else
          {
            alert("Login successfull");
            localStorage.setItem("teachertoken",d.data);
            navigate('/teacherhome');
          }

        }catch(error)
        {
          alert("Something went wrong.. Please try again");
        }

        console.log(data);
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
  
                <h5 className="fw-normal my-4 pb-3" style={{letterSpacing: '1px'}}>Teacher Sign</h5>
  
                  <MDBInput wrapperClass='mb-4' label='Email address' id='formControlLg' type='email' size="lg" ref={emailref}/>
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