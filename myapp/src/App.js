import logo from './logo.svg';
import './App.css';
import React from 'react'
import Home from './Component/InitialPages/Home'
import {Routes, Route, useNavigate} from 'react-router-dom';
import Userlogin from './Component/InitialPages/Userlogin';
import Adminlogin from './Component/InitialPages/Adminlogin';
import Register from './Component/InitialPages/Register';
import Teacherlogin from './Component/InitialPages/Teacherlogin';
import Userapproval from './Component/Adminworks/Userapproval';
import Userrequestagain from './Component/InitialPages/Userrequestagain';
import UserHome from './Component/Userworks/UserHome'
import Adminhome from './Component/Adminworks/Adminhome';
import Subjecthome from './Component/Adminworks/Subjects/Subjecthome';
import Addsubjects from './Component/Adminworks/Subjects/Addsubjects';
import Addbranch from './Component/Adminworks/Subjects/Addbranch';
import Addbranchconnection from './Component/Adminworks/Subjects/Addbranchconnection';
import Branchhome from './Component/Adminworks/Branches/Branchhome';
import Addsubjectconnection from './Component/Adminworks/Branches/Addsubjectconnection';

function App() {
  return (
    <>
      <Routes>
        <Route path="/" element={<Home/>}/>
        <Route path="/userlogin" element={<Userlogin/>}/>
        <Route path="/adminlogin" element={<Adminlogin/>}/>
        <Route path="/register" element={<Register/>}/>
        <Route path="/teacherlogin" element={<Teacherlogin/>}/>
        <Route path="/userapproval" element={<Userapproval/>}/>
        <Route path="/requestagain" element={<Userrequestagain/>}/>
        <Route path="/userhome" element={<UserHome/>}/>
        <Route path="/adminhome" element={<Adminhome/>}/>
        <Route path="/subjecthome" element={<Subjecthome/>}/>
        <Route path="/addsubjects" element={<Addsubjects/>}/>
        <Route path="/addbranch" element={<Addbranch/>}/>
        <Route path="/addbranchconnection" element={<Addbranchconnection/>}/>
        <Route path="/branchhome" element={<Branchhome/>}/>
        <Route path="/addsubjectconnection" element={<Addsubjectconnection/>}/>






      </Routes>
    </>
  );
}

export default App;
