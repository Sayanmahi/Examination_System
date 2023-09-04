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
export default function Addinstitute(){
    const [branches, setBranches] = useState([]);
    const [selectedbrances,setselectedbranches]=useState([]);
    const nameref=useRef();
    const addressref=useRef();
    const cityref=useRef();
    const regionref=useRef();
    const postalcoderef=useRef();
    const phoneref=useRef();
    useEffect(() => {
        fetchOptions(); // Fetch options when the component mounts
      }, []);
      const fetchOptions = async () => {
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
        const data={
            Name:nameref.current.value,
            Address:addressref.current.value,
            City:cityref.current.value,
            PostalCode:postalcoderef.current.value,
            Phone:phoneref.current.value,
            Region:regionref.current.value
        }
        console.log(data);
        try{
            const d= await axios.post(`https://localhost:7062/api/Institute/AddInst`,data);
            alert("Institute added sucessfully");
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

        <h5 className="fw-normal my-4 pb-3" style={{letterSpacing: '1px'}}><b>Add Subject</b></h5>
        <MDBInput wrapperClass='mb-4' label='Institute Name' id='formControlLg' type='text' size="lg" ref={nameref}/>
        <MDBInput wrapperClass='mb-4' label='Address' id='formControlLg' type='text' size="lg" ref={addressref}/>
        <MDBInput wrapperClass='mb-4' label='City' id='formControlLg' type='text' size="lg" ref={cityref}/>
        <MDBInput wrapperClass='mb-4' label='Region' id='formControlLg' type='text' size="lg" ref={regionref}/>
        <MDBInput wrapperClass='mb-4' label='Postal Code' id='formControlLg' type='text' size="lg" ref={postalcoderef}/>
        <MDBInput wrapperClass='mb-4' label='Phone No.' id='formControlLg' type='text' size="lg" ref={phoneref}/>

    <MDBBtn className="mb-4 px-5" color='dark' size='lg' onClick={sub}>Add</MDBBtn>
      </MDBCardBody>
    </MDBCol>

  </MDBRow>
</MDBCard>

</MDBContainer>
        </>
    );
}