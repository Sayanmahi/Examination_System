import {React,useRef,useState,useEffect} from 'react';
import { useNavigate, useSearchParams } from 'react-router-dom';
import axios from 'axios';
export default function Modifyinstitute(props)
{
    const [searchparams]=useSearchParams();
    console.log("Modify "+searchparams.get("id"));
    const navigate=useNavigate();
    const nameref=useRef('');
    const addressref=useRef('');
    const cityref=useRef('');
    const regionref=useRef('');
    const postalref=useRef('');
    const phoneref=useRef('');
    const [namestate,namef]=useState();
    const [addresstate,addressf]=useState();
    const [citystate,cityf]=useState();
    const [regionstate,regionf]=useState();
    const [postalstate,postalf]=useState();
    const [phonestate,phonef]=useState();
    const ss1= localStorage.getItem("admintoken");
    useEffect(() => {
        fetchfunction();
    },[]);
    const fetchfunction=async()=>
    {
        const d=await axios.get(`https://localhost:7062/api/Institute/${searchparams.get("id")}`,{
            headers:{
                'Authorization': `Bearer ${ss1}`
            }
        });
        console.log(d);
        namef(d.data.name);
        addressf(d.data.address);
        cityf(d.data.city);
        regionf(d.data.region);
        postalf(d.data.postalCode);
        phonef(d.data.phone);  
        console.log(d.data.name); 


    }
    const chan = async()=>
    {
        try{
        const fd=
        {
           Name:nameref.current.value,
           Address:addressref.current.value,
           City:cityref.current.value,
           Region:regionref.current.value,
           PostalCode:postalref.current.value,
           Phone:phoneref.current.value

        };
        await axios.put(`https://localhost:7062/api/Institute/Put?id=${searchparams.get("id")}`,fd,{
            headers:{
                'Authorization': `Bearer ${ss1}`
            }
        });
        window.alert("Modified Successfully");
        navigate('/institutehome');
    }catch(e)
    {
        window.alert("Something went Wrong!");
    }

    }

    
    return(
        <>
        <h1><b>Edit Institute Details</b></h1>
        <h1></h1>
        <div class="container">
            <div>
                <h3><b>College/University Name</b></h3>
                <p>{namestate}</p>
                <input type="text" ref={nameref}></input>
            </div>
            <div>
                <h3><b>Address</b></h3>
                <p>{addresstate}</p>
                <input type="text" ref={addressref}></input>
            </div>
            <div>
                <h3><b> Name</b></h3>
                <p>{citystate}</p>
                <input type="text" ref={cityref}></input>
            </div>
            <div>
                <h3><b>Region</b></h3>
                <p>{regionstate}</p>
                <input type="text" ref={regionref}></input>
            </div>
            <div>
                <h3><b>Postal Code</b></h3>
                <p>{postalstate}</p>
                <input type="text" ref={postalref}></input>
            </div>
            <div>
                <h3><b>Phone Number</b></h3>
                <p>{phonestate}</p>
                <input type="text" ref={phoneref}></input>
            </div>
            <button class="btn btn-success" onClick={chan}>Submit Changes</button>
        </div>
        </>
    )
}