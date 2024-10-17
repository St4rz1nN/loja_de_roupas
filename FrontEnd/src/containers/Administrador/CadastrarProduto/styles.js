import styled from "styled-components";
import { Form } from 'react-bootstrap';

export const Container = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    background-color: white;
    justify-content:center;
    align-items: center;
    text-align: center;
`

export const Title = styled.label `
    display: flex;
    flex-direction: row;
    font-size: 50px;
    text-align: center;
    justify-content: initial;
    flex-direction: center;
    height: 10%;
    padding-top:20px;
`

export const Content = styled.form `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    background-color: rgb(240,240,240);
    border-radius: 50px;
    justify-content: center;
    align-items: center;
    padding-left:3%;
`

export const ContentAtributos = styled.div `
    display: flex;
    align-items: initial;
    flex-direction: row;
`

export const ContentInputs = styled.div `
    display: flex;
    height: 100%;
    align-items: initial;
    flex-direction: column;
`

export const ContentPhotos = styled.div `
    display: flex;
    align-items:flex-start;
    justify-content: initial;
    flex-direction: row;
    flex-wrap: wrap;
    height: 150px;
    gap:10px;
`
export const CelulaPhoto = styled.div `
    display: flex;
    height: 150px;
    width: 30%;
    border-radius: 20px;
    box-shadow: 0 10px 10px rgba(0, 0, 0, 0.3);
    overflow: hidden;
    position: relative;
    justify-content: end;
`   

export const ButtonDelete = styled.button `
    position: absolute;
    width:20px;
    height:20px;
    top: 5px;
    right: 5px;
    background: rgba(255, 255, 255, 1); // Fundo semi-transparente
    border: 1px transparent;
    border-radius: 5px;
    padding: 5px;
    cursor: pointer;
    zIndex: 1; // Garante que o botão fique acima da imagem
    transition: transform ease 0 s.2;

    &:hover{
        transform:scale(1.1)
    }
`   

export const Text = styled.label `
    display: flex;
    height: 3%;
    width: 70%;
    border-radius: 10px;
    justify-content:initial;
    margin-top: 30px;
`

export const Input = styled.input`
    height: 5%;
    width: ${props => props.width || '80%'};
    border-radius: 10px;
    box-shadow: 0 0 5px rgba(0, 0, 0, 0.5);
    padding-left: 10px;
    outline: none;
    border: 1px transparent;
    &:focus{
        border-bottom: 2px solid black;
    }
`

export const Select = styled.select`
    height: 5%;
    width: 50%;
    border-radius: 5px;
    border: 1px solid #ccc;
    padding: 5px 10px;
    font-size: 16px;
    background-color: #fff;
    color: #333;
    cursor: pointer;
    outline: none;
    box-shadow: 0 1px 3px rgba(0,0,0,0.1);
    // Estilizando o foco
    &:focus {
        border-color: #007bff; // Cor da borda quando o campo está em foco
        box-shadow: 0 0 5px rgba(0, 123, 255, 0.5); // Efeito de foco
    }
`;

export const Option = styled.option`
    font-size: 16px;
    color: #333;
`;

export const Button = styled.button`
    font-size: 20px;
    color: #333;
    height: 8%;
    width: 40%;
    margin-bottom: 50px;
    border-radius: 20px;
    background-color:white;

    &:hover{
        background-color:black;
        color:white;
    }
`;