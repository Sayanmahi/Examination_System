import React, { useState } from 'react';
import { useRef } from 'react';
import axios from 'axios';
import JWT from "jwt-decode";
const DisplayItem=(props)=>{
    const pp=useRef();
    const [co,costate]=useState(0);
    const gg=localStorage.getItem('subid');
    const handleChange1=async(p)=>
    {
       console.log(p,pp.current.value);
       costate(1);
       if(pp.current.value >=1 && pp.current.value <=4)
       {
        costate(1);
       const d={
        "userId": props.uid,
        "subId": gg,
        "quesId": p,
        "option": pp.current.value
       }
       console.log(d);
       const v= await axios.post(`https://localhost:7062/api/Exam/Storeans`,d);
    }
    else{
        costate(0);
        window.alert("Please provide a valid option!");
    }
    }
    const handleChange2= async(p)=>
    {
        if(pp.current.value>=1 && pp.current.value<=4)
        {
        const d={
            "userId": props.uid,
            "subId": gg,
            "quesId": p,
            "option": pp.current.value
           }
        const v= await axios.put(`https://localhost:7062/api/Exam/Put`,d);
        }
        else{
            window.alert("Please provide a valid option");
        }
    }
    return(
        <>
            <table class="table">
                <thead class="thead-dark">
                <tr>
      
                   <th scope="col"></th>
                </tr>

                </thead>
                <tbody>
                <tr>
      <td><b>{props.title}</b>
      <br />
      <br />
      1. {props.option1}
      <br />
      2. {props.option2}
      <br />
      3. {props.option3}
      <br />
      4. {props.option4}
      <br />
      <label>Choose our option: </label>
      <span></span>
      <input type='number' ref={pp}></input>
      <span></span>
    {co==0 ?(
      <button className='btn btn-success' onClick={()=>handleChange1(props.id)}>Save</button>
    ):(
        <button className='btn btn-danger' onClick={()=>handleChange2(props.id)}>Change</button>
      )}


      </td>
      </tr>
                </tbody>
            </table>
        </>
    );
    }
    export default DisplayItem;