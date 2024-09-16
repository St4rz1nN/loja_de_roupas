import styled from 'styled-components';

// Estilização dos botões e do display do contador
export const Container = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background: rgba(0, 0, 0, 0.5);
  z-index: 1000;
  position: fixed;
  visibility: ${props => props.Visivel ? 'visible' : 'hidden'};
`;

export const ContentModal = styled.div`
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: end;
  text-align: center;
  border-radius: ${props => props.Width/15}px;
  width: ${props => props.Width}px;
  height: ${props => props.Height}px;
  box-shadow: 0 ${props => props.boxshadow ? `${props.Width/20}px ${props.Width/10}px rgba(0, 0, 0, 0.1)` : '0'};
  background: ${props => props.background};
  z-index: 1000;
  position: fixed;
  padding: 15px;
  gap: 20px;
  transform: ${props => (props.Visivel ? 'scale(1)' : 'scale(0.8)')};
  opacity: ${props => (props.Visivel ? '1' : '0')};
  transition: transform 0.3s ease, opacity 0.3s ease;
  will-change: transform, opacity;
`;

export const Button = styled.button`
  display: flex;
  align-items: center;
  text-align: center;
  justify-content: center;
  border-radius: ${props => props.Height/30}px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  width: 30%;
  height: 15%;
  background: rgba(0, 0, 0, 1);
  color: white;
    
  &:hover{
    background: rgba(255, 255, 255, 1);
    color: black;
  }
`;

export const Text = styled.label`
  display: flex;
  font-size: ${props => props.TextTamanho}px;
  height: ${props => props.Height}%;
  text-align: center;
  align-items: center;
  justify-content: center;
`;


export const Spinner = styled.div`
  border: 8px solid rgba(0, 0, 0, 0.1);
  border-left: 8px solid #3498db; /* Cor da rodinha */
  border-radius: 50%;
  width: 40px;
  height: 40px;
  animation: spin 1s linear infinite;

  @keyframes spin {
    0% { transform: rotate(0deg); }
    100% { transform: rotate(360deg); }
  }
`;