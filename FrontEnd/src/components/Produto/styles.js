import styled from "styled-components";
import background2 from '../../assets/images/imagemteste.png'
import { Link } from 'react-router-dom';

export const Container = styled(Link) `
    display: flex;
    flex-direction: column;
    height: 100%;
    width: 100%;
    padding: 10px;
    text-decoration: none;
`

export const Photo = styled.div `
    display: flex;
    background-image: url(${props => props.background});
    background-size: cover;
    background-position: center;
    background-repeat: no-repeat;
    height: 70%;
    width: 100%;
    border-radius: 30px;
`   

export const ContentAtributos = styled.div `
    display: flex;
    height: 30%;
    flex-direction: column;
    padding: 10px;
    gap: 3px;
`

export const NomeText = styled.label `
    color: black;
    font-size: 15px;
    width: 100%;
    text-align: initial;
    padding-bottom: 3px;
    font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
`

export const ContentTamanho = styled.div `
    display:flex;
    flex-direction:row;
    width: 100%;
    height: 60px;
    gap: 5px;
`

export const Tamanho = styled.label `
    color: black;
    font-size: 10px;
    text-align: initial;
    width: 15px;
    height: 15px;
    border-radius: 10px;
    border: 1px solid black;
    text-align: center;
    font-family: Impact, Haettenschweiler, 'Arial Narrow Bold', sans-serif;
`

export const ContentCor = styled.div `
    display:flex;
    flex-direction:row;
    width: 100%;
    gap: 5px;
`

export const PrecoText = styled.div `
    color: black;
    font-size: 15px;    
    width: 30%;
    text-align: initial;
`