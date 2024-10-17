import Header from '../../components/Header/index.jsx'
import { Container } from './styles.js'
import { useEffect } from 'react'

function Principal(){
    
    useEffect(() => {
        localStorage.setItem('modoadm', false);
    }, []);

    return (
        <Container>
            <Header
                administrador={false}
                subLinks={true}
            />
        </Container>
    )
}

export default Principal;