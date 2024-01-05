import React, { useEffect, useRef, useState } from 'react'
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import "bootstrap/dist/css/bootstrap.min.css";
import {Routes, Route, useNavigate,createSearchParams,useSearchParams} from 'react-router-dom';
import axios from 'axios';
export default function Addmodify(props) {
  const navigate=useNavigate();
  const [searchparams]=useSearchParams();
    const idref=useRef('');
    const titleref=useRef('');
    const opt1ref=useRef('');
    const opt2ref=useRef('');
    const opt3ref=useRef('');
    const opt4ref=useRef('');
    const correctidref=useRef('');
    const wrongmarkref=useRef('');
    const correctmarkref=useRef('');
    const subidref=useRef('');
    const [data,datastate]=useState([]);
    useEffect(() => {
        fetchfunction();
    },[]);
    const fetchfunction=async()=>
    {
        const d=await axios.post(`https://localhost:7062/api/Question/GetQuestionsbySubId?id=${searchparams.get("id")}`);
        console.log(d.data);
        datastate(d.data);
    }
    const del=async(e)=>
    {
      console.log(e);
       const d= await axios.delete(`https://localhost:7062/api/Question/Delete?id=${e}`);
       console.log("eeeeeeeeeeeeeeeeeee",d);
       navigate('/teacherhome');
    }
    function modify(e)
    {
      navigate({
        pathname:'/modifyquestion',
        search:createSearchParams({
        id:e
        }).toString()
    });
    }

    return(
    <>
    <table class="table">
  <thead class="thead-dark">
    <tr>
      <th scope="col">Id</th>
      <th scope="col">Title</th>
      <th scope="col">Option1</th>
      <th scope="col">Option2</th>
      <th scope="col">Option3</th>
      <th scope="col">Option4</th>
      <th scope="col">Correct Option</th>
      <th scope='col'>Wrong Mark</th>
      <th scope="col">Correct Mark</th>
      <th scope="col">Actions</th>
    </tr>
  </thead>
  <tbody>
  {data.map((option) => (
    <tr>
      <th scope="row">{option.id}</th>
      <td>{option.title}</td>
      <td>{option.option1}</td>
      <td>{option.option2}</td>
      <td>{option.option3}</td>
      <td>{option.option4}</td>
      <td>{option.correctId}</td>
      <td>{option.wrongMark}</td>
      <td>{option.correctMark}</td>
      <td><button class="btn btn-success" onClick={() => modify(option.id)}>Edit</button>
      <button class="btn btn-danger" onClick={() => del(option.id)}>Delete</button></td>
    </tr>
  ))}
  </tbody>
    </table>
    </>
    );
}