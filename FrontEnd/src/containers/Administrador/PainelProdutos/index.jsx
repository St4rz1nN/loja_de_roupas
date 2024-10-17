import Header from '../../../components/Header/index.jsx'
import { Container, ContentPrincipal, CelulaContent } from './styles.js'
import { PiCashRegisterLight } from "react-icons/pi";
import { RiSearchEyeLine } from "react-icons/ri";
import { useEffect } from 'react';

function PainelProdutos(){

    const handleModoAdm = () => {
        localStorage.setItem('modoadm', true);
    }

    const handleCadastro = () => {
        localStorage.removeItem('produtoselecionadoedit');
    }

    return (
        <Container>
            <Header
                titleName="Painel Administrador"
                administrador={true}
                subLinks={false}
            />
            <ContentPrincipal>
                <CelulaContent Link to="/cadastrarproduto" onClick={handleCadastro}>
                    <PiCashRegisterLight
                    size={5} color="#ffffff"
                    />
                    Cadastrar Produto
                </CelulaContent>

                <CelulaContent Link to="/produtos" onClick={handleModoAdm}>
                    <RiSearchEyeLine
                    size={5} color="#ffffff"
                    />
                    Ver Produtos
                </CelulaContent>
            </ContentPrincipal>
        </Container>
    )
}

export default PainelProdutos;