import styled from "styled-components";
import background from '../../assets/images/background.png'

export const Container = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    background-color: white;
`

export const Celula = styled.div `
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    height: 500px;
    width: 24%;
    cursor: pointer;
    transition: transform 0.2s ease-in-out;
    &:hover{
        transform: scale(1.03);
    }
`

