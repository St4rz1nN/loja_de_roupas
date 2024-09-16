import { Container, ContentPrincipal, ContentTitle, Title, Menu, CloseMenu, NavLinks, Ancora, ContentSecundario, ContentSubProdutos, ContainerSubProdutos, ContentSubLinks, Text, TextSubProduto } from "./styles"
import { useState } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';

const Header = ( { titleName }) => {

    const ancoras = [
    {
        nome: "Produtos",
        url: "/produtos",
        subprodutos: [{
            nome: "ROUPAS",
            filtros:["Ver Tudo Em Roupas","Camisas", "TácTeis", "Camisas Manga Longa", "Casacos e Moletons", "Calças", "Shorts e Bermudas"],
            },
            {
            nome: "ROUPAS ESPORTIVAS",
            filtros:["Ver Tudo Em Esportivos", "Regatas", "Camisetas Esportivas", "Bonés"],
            },
            {
            nome: "ROUPAS INTIMAS",
            filtros:["Ver Tudo Em Intimas", "Cuecas", "Meias"],
            },
            ],
    },
    {
        nome: "Sobre Nós",
        url: "/sobrenos",
    },
    {
        nome: "Area Cliente",
        url: "/areacliente"
    }];
    
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    const [isOvered, setIsOvered] = useState(false);

    const [lastOvered, setLastOvered] = useState(false);

    const toggleMenu = () => {
        setIsMenuOpen(state => !state);
    }

    const handleMouseEnter = (nome) => () => {
        if(nome == "Produtos" || nome == "Sobre Nós"){
            setIsOvered(nome);
            setLastOvered(nome);
        }else{
            setIsOvered(false);
        }
        console.log(nome);
    }

    const handleMouseLeave = () => {
        setIsOvered(false);
    };
    
    const renderSubLinks = (tipo) => {
        if(tipo == "Produtos"){
            return (
                ancoras.map(ancora => {
                    if(ancora.nome == "Produtos"){
                        return(
                            <ContainerSubProdutos>
                                <ContentSubProdutos key={ancora.nome}>
                                    {ancora.subprodutos && ancora.subprodutos.length > 0 ? (
                                        ancora.subprodutos.map((subproduto) => (
                                            <div>
                                                <TextSubProduto>{subproduto.nome}</TextSubProduto>
                                                <ContentSubLinks key={subproduto.nome}> 
                                                    {subproduto.filtros && subproduto.filtros.length > 0 ? (
                                                        subproduto.filtros.map((filtro) => (
                                                            <Text key={filtro}>{filtro}</Text>
                                                        ))
                                                    ) : null}
                                                </ContentSubLinks>
                                            </div>
                                        ))
                                    ) : null}
                                </ContentSubProdutos>
                            </ContainerSubProdutos>
                        );
                    };
                })
            );
        }
    }


    return (

        <Container>
            <ContentPrincipal>
                <ContentTitle>
                    <Title to="/">{titleName}</Title>
                </ContentTitle>
                <NavLinks isMenuOpen={isMenuOpen}>
                    <CloseMenu onClick={toggleMenu}>X</CloseMenu>
                    {
                    ancoras.map(ancora => 
                    <Ancora key={ancora.nome} to={ancora.url} onMouseEnter={handleMouseEnter(ancora.nome)} onMouseLeave={handleMouseLeave}>{ancora.nome}
                    </Ancora>
                    )}
                </NavLinks>
                <Menu onClick={toggleMenu}>☰</Menu>
            </ContentPrincipal >
            <ContentSecundario AncoraOvered={isOvered} onMouseEnter={handleMouseEnter(isOvered)} onMouseLeave={handleMouseLeave}>
                {isOvered ? (
                    renderSubLinks(isOvered)
                ): renderSubLinks(lastOvered)
                }
            </ContentSecundario>
        </Container>
    )
}

export default Header;
