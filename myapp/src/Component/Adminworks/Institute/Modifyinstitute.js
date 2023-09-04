import {React,useRef,useState,useEffect} from 'react';
import { useSearchParams } from 'react-router-dom';
export default function Modifyinstitute(props)
{
    const [searchparams]=useSearchParams();
    console.log("Modify "+searchparams.get("id"));
    return(
        <h1>{searchparams.get("id")}</h1>
    )
}