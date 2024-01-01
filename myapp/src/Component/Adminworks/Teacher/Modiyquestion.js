import React, { useEffect, useRef, useState } from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import {Routes, Route, useNavigate,useSearchParams} from 'react-router-dom';
import axios from 'axios';
export default function Modifyquestion(props){
    const navigate=useNavigate();
    const [searchparams]=useSearchParams();
    const[title,titlestate]=useState();
    const[opt1,opt1state]=useState();
    const[opt2,opt2state]=useState();
    const[opt3,opt3state]=useState();
    const[opt4,opt4state]=useState();
    const[corro,corrostate]=useState();
    const[wron,wronstate]=useState();
    const[corr,corrstate]=useState();
    const[subId,substate]=useState();
    useEffect(() => {
        fetchfunction();
    },[]);
    const fetchfunction=async()=>
    {
        const d=await axios.get(`https://localhost:7062/api/Question/Getquestionbyid?id=${searchparams.get("id")}`);
        console.log(d);
        titlestate(d.data.title);
        opt1state(d.data.option1);
        opt2state(d.data.option2);
        opt3state(d.data.option3);
        opt4state(d.data.option4);
        corrostate(d.data.correctId);
        wronstate(d.data.wrongMark);
        corrstate(d.data.correctMark);
        substate(d.data.subId);
    }
    const edits =async()=>
    {
        const data={
            Title:title,
            Option1:opt1,
            Option2:opt2,
            Option3:opt3,
            Option4:opt4,
            CorrectId:corro,
            WrongMark:wron,
            correctMark:corr,
            SubId:subId
        };
        console.log(data);
        const d=await axios.put(`https://localhost:7062/api/Question/Put?id=${searchparams.get("id")}`,data);
        navigate('/addmodify');

    }
    return(
        <>
        <div class="container">
        <h1><b>Edit Fields</b></h1>
        <label><b>Title</b></label>
        <p>{title}</p>
        <input onChange={e => titlestate(e.target.value)} />
        <br/>
        <label><b>Option 1</b></label>
        <p>{opt1}</p>
        <input onChange={e => opt1state(e.target.value)} />
        <br/>
        <label><b>Option 2</b></label>
        <p>{opt2}</p>
        <input onChange={e => opt2state(e.target.value)} />
        <br/>
        <label><b>Option 3</b></label>
        <p>{opt3}</p>
        <input onChange={e => opt3state(e.target.value)} />
        <br/>
        <label><b>Option 4</b></label>
        <p>{opt4}</p>
        <input onChange={e => opt4state(e.target.value)} />
        <br/>
        <label><b>Correct Option</b></label>
        <p>{corro}</p>
        <input onChange={e => corrostate(e.target.value)} />
        <br/>
        <label><b>Wrong Marks</b></label>
        <p>{wron}</p>
        <input onChange={e => wronstate(e.target.value)} />
        <br/>
        <label><b>Correct Mark</b></label>
        <p>{corr}</p>
        <input onChange={e => corrstate(e.target.value)} />
        <br/>
        <button class="btn btn-success" onClick={edits}>Submit</button>
        </div>
        </>

    );

}