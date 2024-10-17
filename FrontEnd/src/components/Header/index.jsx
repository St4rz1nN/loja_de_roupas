import { Icon, Container, ContentPrincipal, ContentTitle, Title, Menu, CloseMenu, NavLinks, Ancora, ContentSecundario, ContentSubProdutos, ContainerSubProdutos, ContentSubLinks, Text, TextSubProduto } from "./styles"
import { useState, useEffect } from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import { RxExit } from "react-icons/rx";


const Header = ( { administrador, subLinks }) => {

    const [title, setTitle] = useState("LOJA ROUPAS");
    const [ancoras, setAncoras] = useState([
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
            url: "/areacliente",
        }]);

    useEffect(() => {
        if(administrador){
            setAncoras([
                {
                    nome: "Produtos",
                    url: "/PainelProdutos",
                },
                {
                    nome: "Sair",
                    url: "/",
                    icon: RxExit,
                }
            ]);

            setTitle("PAINEL ADMINISTRADOR");

                
        }
    },[administrador]);

    
    const [isMenuOpen, setIsMenuOpen] = useState(false);

    const [isOvered, setIsOvered] = useState(false);

    const [lastOvered, setLastOvered] = useState(false);

    const toggleMenu = () => {
        setIsMenuOpen(state => !state);
    }

    const handleMouseEnter = (nome) => () => {
        if(subLinks){
            if(nome == "Produtos" || nome == "Sobre Nós"){
                setIsOvered(nome);
                setLastOvered(nome);
            }else{
                setIsOvered(false);
            }
            console.log(nome);
        }
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
                    <Title to={administrador ? "/PainelAdministrador" : "/"}>{title}</Title>
                </ContentTitle>
                <NavLinks isMenuOpen={isMenuOpen}>
                    <CloseMenu onClick={toggleMenu}>X</CloseMenu>
                    {
                    ancoras.map(ancora => 
                    <Ancora key={ancora.nome} to={ancora.url} onMouseEnter={handleMouseEnter(ancora.nome)} onMouseLeave={handleMouseLeave}>
                        {ancora.nome ? ancora.nome : null}
                        {ancora.icon ?
                            <Icon>
                                <ancora.icon
                                    size={20}
                                />
                            </Icon> 
                            : null}
                    </Ancora>
                    )}
                </NavLinks>
                <Menu onClick={toggleMenu}>☰</Menu>
            </ContentPrincipal >
            <ContentSecundario AncoraOvered={isOvered} onMouseEnter={handleMouseEnter(isOvered)} onMouseLeave={handleMouseLeave}>
                {
                    isOvered ? (
                        renderSubLinks(isOvered)
                    ): renderSubLinks(lastOvered)
                }
            </ContentSecundario>
        </Container>
    )
}

export default Header;
