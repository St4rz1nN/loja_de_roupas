import styled from 'styled-components';

// Estilização dos botões e do display do contador
export const Container = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  border: 1px solid #e0e0e0;
  border-radius: 8px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: ${props => props.tamanho}px;
  height: ${props => props.tamanho/3}px;
`;

export const Button = styled.button`
  color: #333;
  background-color: white;
  border: 0px;
  font-size: ${props => props.tamanho/6}px;
  cursor: pointer;
`;

export const CountDisplay = styled.span`
  font-size: ${props => props.tamanho/8}px;
  font-weight: 500;
  color: #333;
  display:flex;
  align-items: center;
  justify-content: center;
`;
