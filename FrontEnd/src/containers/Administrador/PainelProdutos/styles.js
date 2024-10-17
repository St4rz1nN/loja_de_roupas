import styled from "styled-components";
import { Link } from 'react-router-dom';

export const Container = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    background-color: white;
    justify-content:initial;
    align-items: center;
    text-align: center;
`

export const ContentPrincipal = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: row;
    background-color: white;
    flex-wrap: wrap;
    gap: 50px;
    justify-content:center;
    align-items: center;
    text-align: center;
`

export const CelulaContent = styled(Link) `
    height: 30%;
    width: 30%;
    display: flex;
    flex-direction: column;
    background-color: black;
    align-items: center;
    text-align: center;
    color:white;
    justify-content:center;
    font-size: 30px;
    border-radius:30px;
    cursor: pointer;
    box-shadow: 0 10px 10px rgba(0, 0, 0, 0.3);
    transition: transform 0.2s ease-in-out;
    text-decoration: none;
    
    &:hover{
        transform: scale(1.03);
    }
`