import React from 'react';
import { useRef } from 'react';
const DisplayItem=(props)=>{
    const pp=useRef();
    const handleChange1=async(p)=>
    {
       console.log(p,pp.current.value);
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
      <button className='btn btn-success' onClick={()=>handleChange1(props.id)}>Save</button>

      </td>
      </tr>
                </tbody>
            </table>
        </>
    );
    }
    export default DisplayItem;