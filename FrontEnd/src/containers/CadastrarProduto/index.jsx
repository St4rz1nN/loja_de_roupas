import { Container, Content, Title, Text, Select, Option, Button } from './styles.js'
import { useState } from 'react';
import Modal from '../../components/Modal';
import { Input } from 'react-bootstrap';

function CadastrarProduto(){
    
    //Modal

    const [modalVisivel, setModalVisivel] = useState(false);
    const [tipoModal, setTipoModal] = useState("");
    const [mensagemModal, setMensagemModal] = useState("");
    const [textTamanho, setTextTamanho] = useState(40);
    const [modalHeight, setModalHeight] = useState(300);
    const [modalWidth, setModalWidth] = useState(600);
    const handleModal = (Tipo, Mensagem, Height, Width, TextTamanho) => {
        setTipoModal(Tipo);
        setMensagemModal(Mensagem);
        setModalVisivel(true);
        setModalHeight(Height)
        setModalWidth(Width)
        setTextTamanho(TextTamanho)
      }
    const closeModal = () => {
        setModalVisivel(false);
    };


    //Variaveis
    const [formData, setFormData] = useState({
        nome: '',
        tipo: 'camisa',
        tamanho: 'p',
        cor: 'vermelho',
        valor: '0',
    });



    //erro efeito
    const [errors, setErrors] = useState({
        nome: false,
        tipo: false,
        tamanho: false,
        cor: false,
        valor: false
    });

    const handleChange = (event) => {
        const {name, value} = event.target;
        setFormData({
            ...formData,
            [name]: value
        }
        )
    }

    const cadastrarProduto = () =>{
        console.log(formData.nome)
        console.log(formData.tipo)
        console.log(formData.tamanho)
        console.log(formData.cor)
        console.log(formData.valor)

        event.preventDefault();

        let hasErrors = false;
        const newErrors = {};

        Object.keys(formData).forEach((key) => {
            if (formData[key].trim() === '') {
                newErrors[key] = true;
                hasErrors = true;
            }else{
                newErrors[key] = false;
            }
        });

        if (hasErrors) {
            setErrors(newErrors);
            console.log(errors.nome)
            console.log(errors.tipo)
            console.log(errors.tamanho)
            console.log(errors.cor)
            console.log(errors.valor)
            return;
        }
    }

    return (
        <Container>
            <Modal
            Height={modalHeight}
            Width={modalWidth}
            Tipo={tipoModal}
            Mensagem={mensagemModal}
            Visivel={modalVisivel}
            TextTamanho={textTamanho}
            OnClick={closeModal}
            />
            <Title>
                Cadastrar Produto
            </Title>
            <Content>
                <Text>
                    Nome
                </Text>
                <Input required placeholder="Insira o Nome da roupa..." value={formData.nome} name="nome" onChange={handleChange} hasError={errors.nome}>
                </Input>
                <Text>
                    Tipo
                </Text>
                <Select placeholder="Insira a Cor da roupa..." value={formData.tipo} name="tipo" onChange={handleChange} hasError={errors.tipo}>
                    <Option value="camisa">Camisa</Option>
                    <Option value="camiseta">Camiseta</Option>
                </Select>
                <Text>
                    Tamanho
                </Text>
                <Select placeholder="Insira a Cor da roupa..." value={formData.tamanho} name="tamanho" onChange={handleChange} hasError={errors.tamanho}>
                    <Option value="p">P (Pequeno)</Option>
                    <Option value="m">M (Médio)</Option>
                    <Option value="g">G (Grande)</Option>
                    <Option value="gg">GG (Extra Grande)</Option>
                </Select>
                <Text>
                    Cor
                </Text>
                <Select placeholder="Insira a Cor da roupa..." value={formData.cor} name="cor" onChange={handleChange} hasError={errors.cor}>
                    <Option value="vermelho">Vermelho</Option>
                    <Option value="verde">Verde</Option>
                    <Option value="azul">Azul</Option>
                    <Option value="amarelo">Amarelo</Option>
                    <Option value="laranja">Laranja</Option>
                    <Option value="roxo">Roxo</Option>
                    <Option value="rosa">Rosa</Option>
                    <Option value="cinza">Cinza</Option>
                </Select>
                <Text>
                    Valor
                </Text>
                <Input placeholder="Insira o Valor da roupa..." type="number" step="0.01"  value={formData.valor} name="valor" onChange={handleChange} hasError={errors.valor}> 
                </Input>

                <Button onClick={cadastrarProduto}>
                    Cadastrar Produto
                </Button>
            </Content>
        </Container>
    )
}

export default CadastrarProduto;