import Header from '../../../components/Header/index.jsx'
import { Container } from './styles.js'


function Principal(){
    const ancoras = [
        {
            nome: "Produtos",
            url: "/produtos",
        },
        {
            nome: "Cadastrar Produto",
            url: "/cadastrarproduto",
        },
        {
            nome: "Area Cliente",
            url: "/areacliente"
        }];

    return (
        <Container>
            <Header
                titleName="Painel Administrador"
                administrador={true}
                subLinks={false}
            />
        </Container>
    )
}

export default Principal;