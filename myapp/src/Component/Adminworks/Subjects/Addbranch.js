import { useNavigate } from 'react-router-dom';
import axios from 'axios';
import {React,useRef,useState,useEffect} from 'react';
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
  import '../../../App.css'
  import "bootstrap/dist/css/bootstrap.min.css";
export default function Addbranch(){
    const [branches, setBranches] = useState([]);
    const [selectedbrances,setselectedbranches]=useState([]);
    const ss= localStorage.getItem("admintoken");
    const nameref=useRef();
    useEffect(() => {
        fetchOptions(); // Fetch options when the component mounts
      }, []);
      const fetchOptions = async () => {
        try {
          const response = await fetch(
            "https://localhost:7062/api/Subject/GetSubjects"
          ); // Replace with your API endpoint
          const data = await response.json();
          setBranches(data); // Set the received data as options
        } catch (error) {
          console.error("Error fetching options:", error);
        }
      };
      const sub=async()=>
      {
        const data={
            Name:nameref.current.value,
            subjectIds:selectedbrances
        }
        console.log(selectedbrances);
        console.log(data);
        try{
            const d= await axios.post(`https://localhost:7062/api/Branch/AddBranch`,data,{
              headers:{
                'Authorization': `Bearer ${ss}`
            }
            });
            alert("Branch added sucessfully");
        }catch(error)
        {
            alert("Something went wrong");
        }
      }
    return(
        <>
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

        <h5 className="fw-normal my-4 pb-3" style={{letterSpacing: '1px'}}><b>Add Branch</b></h5>
        <MDBInput wrapperClass='mb-4' label='Subject Name' id='formControlLg' type='text' size="lg" ref={nameref}/>
          <div className="container">
          <select className="my-select" isMulti onChange={(e)=>{
          console.log("branches "+e.target.value);
          setselectedbranches( arr => [...arr,e.target.value]);
         
          }
          }>
      <option value="">Select an option</option>
      {branches && branches.map((option) => (
        <option key={option.id} value={option.id}>
          {option.name}
        </option>
      ))}
    </select>
    </div>
    <MDBBtn className="mb-4 px-5" color='dark' size='lg' onClick={sub}>Add</MDBBtn>
      </MDBCardBody>
    </MDBCol>

  </MDBRow>
</MDBCard>

</MDBContainer>
        </>
    );
}