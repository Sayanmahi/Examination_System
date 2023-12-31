import React, { useEffect, useRef, useState } from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import {Routes, Route, useNavigate,useSearchParams} from 'react-router-dom';
import axios from 'axios';
export default function Modifyquestion(props){
    const [searchparams]=useSearchParams();
    useEffect(() => {
        fetchfunction();
    },[]);
    const fetchfunction=async()=>
    {
        const d=await axios.get(`https://localhost:7062/api/Question/Getquestionbyid?id=${searchparams.get("id")}`);
        console.log(d);
}
}