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





      </Routes>
    </>
  );
}

export default App;
