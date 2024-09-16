import styled from "styled-components";

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
    flex-direction: column;
    font-size: 50px;
    text-align: center;
    justify-content: center;
    height: 15%;
`

export const Content = styled.div `
    height: 80%;
    width: 50%;
    display: flex;
    flex-direction: column;
    background-color: rgb(240,240,240);
    border-radius: 50px;
    justify-content: center;
    align-items: initial;
    padding-left:12%;
`

export const Text = styled.label `
    display: flex;
    height: 3%;
    width: 70%;
    border-radius: 10px;
    justify-content:initial;
    margin-top: 30px;
`

export const Input = styled.input `
    height: 5%;
    width: 70%;
    border-radius: 10px;
    box-shadow: ${props => props.hasError ? '0 1px 1px rgba(0,0,0,0.3)' : '0 0 5px rgba(231, 76, 60, 0.5)'};
    padding-left: 10px;
    outline: none;
    border: ${props => props.hasError ? '1px red' : '1px transparent'};
    &:focus{
        border-bottom: 2px solid black;
    }
`

export const Select = styled.select`
    height: 5%;
    width: 30%;
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
    margin-left: 15%;
    margin-top: 50px;
    border-radius: 20px;
    background-color:white;

    &:hover{
        background-color:black;
        color:white;
    }
`;