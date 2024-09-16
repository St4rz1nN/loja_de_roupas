import styled from "styled-components";

export const Container = styled.div `
    height: 100%;
    width: 100%;
    display: flex;
    flex-direction: column;
    background-color: white;
`

export const ContentFiltro = styled.div `
    display: flex;
    height: 200px;
    flex-direction: column;
    padding: 10px;
`

export const TextFiltro = styled.label `
    font-size: 20px;
    color: black;
    height: 40px;
    font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
`

export const ContentSubFiltro = styled.div `
    display: flex;
    flex-direction: column;
    height: 50px;
    gap:8px;
`

export const CheckBox = styled.input.attrs({ type: 'checkbox' })`

    width: 12px;
    height: 12px;
    cursor: pointer;
    accent-color: black; /* Defina a cor de destaque (disponível no CSS moderno) */
    margin-right: 8px;
    
    &:hover {
        background-color: black;
    }

    &:checked {
        background-color: black;
    }

    &:disabled {
        cursor: not-allowed;
        opacity: 0.5;
    }
`

export const TextSubFiltro = styled.label `
    font-size: 15px;
    color: black;
`