import { Container, Content, ContentPhotos, CelulaPhoto, ContentAtributos, ContentInputs, ButtonDelete, Title, Text, Select, Option, Button, Input } from './styles.js'
import { useState, useEffect } from 'react';
import Modal from '../../../components/Modal/index.jsx';
import { Form } from 'react-bootstrap';
import api from '../../../services/api.js'
import { FaTrash } from 'react-icons/fa';
import Header from '../../../components/Header/index.jsx'

function CadastrarProduto(){
    

    const [modoEdicao, setModoEdicao] = useState(false);

    const [buttonTitle, setButtonTitle] = useState("CADASTRAR PRODUTO");

    const [modalVisivel, setModalVisivel] = useState(true);
    const [tipoModal, setTipoModal] = useState("Carregando");
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
        tipo: 'Camisa',
        tamanho: 'P',
        cor: 'Vermelho',
        valor: '0',
    });

    const [arquivos, setArquivos] = useState([]);
    const [title, setTitle] = useState("");
    const [objeto, setObjeto] = useState(null);

    const handleChange = (event) => {
        const {name, value} = event.target;
        setFormData({
            ...formData,
            [name]: value
        }
        )
    }

    const handleRemove = (index) => {
        // Lógica para remover a foto
        setArquivos((prevArquivos) => prevArquivos.filter((_, i) => i !== index));
    };

    const handleFileChange = (e) => {
        var files = Array.from(e.target.files);
        var arquivosNovos = files.concat(arquivos);
        setArquivos(arquivosNovos);
        console.log(arquivosNovos);
    };

    const cadastrarProdutoAsync = async (produto) => {
        try{
            const formDataApi = new FormData();

            formDataApi.append('Nome', formData.nome);
            formDataApi.append('Tipo', formData.tipo);
            formDataApi.append('Tamanho', formData.tamanho);
            formDataApi.append('Cor', formData.cor);
            formDataApi.append('Valor', parseInt(formData.valor));

            arquivos.forEach(arquivo => {
                formDataApi.append('photos', arquivo);
            });
            
            const response = await api.post('produto',formDataApi, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            handleModal("Alerta", `Sucesso ao Cadastrar Produdo!:`,300,600,20)
        }catch(error){
            handleModal("Alerta", `Erro ao cadastrar Produto: + ${error.message}`,300,600,20)
        }
    }

    const editarProdutoAsync = async (produto) => {
        try{
            const formDataApi = new FormData();

            formDataApi.append('Nome', formData.nome);
            formDataApi.append('Tipo', formData.tipo);
            formDataApi.append('Tamanho', formData.tamanho);
            formDataApi.append('Cor', formData.cor);
            formDataApi.append('Valor', parseInt(formData.valor));

            arquivos.forEach(arquivo => {
                formDataApi.append('photos', arquivo);
            });
            
            const response = await api.put('produto',formDataApi, {
                headers: {
                    'Content-Type': 'multipart/form-data'
                }
            });
            handleModal("Alerta", `Sucesso ao Editar Produdo!:`,300,600,20)
        }catch(error){
            handleModal("Alerta", `Erro ao Editar Produto: + ${error.message}`,300,600,20)
        }
    }


    const cadastrarProduto = (event) => {
        event.preventDefault();

        const form = event.target;
        if (form.checkValidity()) {
            cadastrarProdutoAsync();
        } else {
            form.reportValidity();
        }
    };

    const editarProduto = (event) => {
        event.preventDefault();
        
        const form = event.target;
        if (form.checkValidity()) {
           editarProdutoAsync();
        } else {
            form.reportValidity();
        }
    };

    const resgatarProduto = async (Id) => {
        try{
            const response = await api.get(`produto/${Id}`);
            console.log("Resposta da API:", response.data);
            setObjeto(response.data);
            setModalVisivel(false);

            formData.nome = response.data.nome;
            formData.tipo = response.data.tipo;
            formData.tamanho = response.data.tamanho;
            formData.cor = response.data.cor;
            formData.valor = response.data.valor;


        }catch(error){
            handleModal("Alerta", `Erro ao resgatar o Produto: + ${error}`,300,600,20)
        }
    };

    useEffect(() => {
        const produtoID = localStorage.getItem('produtoselecionadoedit');
        if (!produtoID){
            setTitle("Cadastrar Produto");
            setModalVisivel(false);
        }else{
            setModoEdicao(true);
            setTitle("Editar Produto")
            console.log("Id Resgatado: " + produtoID)
            resgatarProduto(produtoID)
            setButtonTitle("EDITAR PRODUTO")
        }
    }, []);
    
    const dataURLtoFile = (dataURL, filename) => {
        const arr = dataURL.split(','); // Divide o Data URL em partes
        const mime = arr[0].match(/:(.*?);/)[1]; // Obtém o tipo MIME
        const byteString = atob(arr[1]); // Converte o Base64 para uma string de bytes
        const arrayBuffer = new Uint8Array(byteString.length); // Cria um ArrayBuffer
    
        // Preenche o ArrayBuffer
        for (let i = 0; i < byteString.length; i++) {
            arrayBuffer[i] = byteString.charCodeAt(i);
        }
    
        // Cria um Blob e um File
        const blob = new Blob([arrayBuffer], { type: mime });
        return new File([blob], filename, { type: mime });
    };

    useEffect(() => {
        if(objeto){
            const resgatarFotos = async () => {
                try{
                    const response = await api.get(`produto/foto/${objeto.id}`);
                    const data = response.data;

                    const fotosToFile = data.map(item => {
                        const filename = item.fileName; // Nome do arquivo
                        return dataURLtoFile(item.dataUrl, filename); // Converte o Data URL em um arquivo
                    });

                    setArquivos(fotosToFile);
                }catch(error){
                    console.log('Erro ao resgatar Foto: ' + error);
                }
            }
            resgatarFotos();
        }
    }, [objeto]);

    return (
        <Container>
            <Header
                titleName="Painel Administrador"
                administrador={true}
                subLinks={false}
            />
            <Modal
            Height={modalHeight}
            Width={modalWidth}
            Tipo={tipoModal}
            Mensagem={mensagemModal}
            Visivel={modalVisivel}
            TextTamanho={textTamanho}
            OnClick={closeModal}
            />
            <Content onSubmit={modoEdicao ? editarProduto : cadastrarProduto}>
                <Title>
                    {title}
                </Title>
                <ContentAtributos>
                    <ContentInputs>
                        <Text>
                            Nome
                        </Text>
                        <Input
                            type="text"
                            placeholder="Nome do produto"
                            value={formData.nome}
                            name="nome"
                            onChange={handleChange}
                            required
                        />
                        <Text>
                            Tipo
                        </Text>
                        <Select placeholder="Insira a Cor da roupa..." value={formData.tipo} name="tipo" onChange={handleChange}>
                            <Option value="Camisa">Camisa</Option>
                            <Option value="Camiseta">Camiseta</Option>
                        </Select>
                        <Text>
                            Tamanho
                        </Text>
                        <Select placeholder="Insira a Cor da roupa..." value={formData.tamanho} name="tamanho" onChange={handleChange}>
                            <Option value="P">P (Pequeno)</Option>
                            <Option value="M">M (Médio)</Option>
                            <Option value="G">G (Grande)</Option>
                            <Option value="GG">GG (Extra Grande)</Option>
                        </Select>
                        <Text>
                            Cor
                        </Text>
                        <Select placeholder="Insira a Cor da roupa..." value={formData.cor} name="cor" onChange={handleChange}>
                            <Option value="Vermelho">Vermelho</Option>
                            <Option value="Verde">Verde</Option>
                            <Option value="Azul">Azul</Option>
                            <Option value="Amarelo">Amarelo</Option>
                            <Option value="Laranja">Laranja</Option>
                            <Option value="Roxo">Roxo</Option>
                            <Option value="Rosa">Rosa</Option>
                            <Option value="Cinza">Cinza</Option>
                        </Select>
                        <Text>
                            Valor
                        </Text>
                        <Input placeholder="Insira o Valor da roupa..." type="number" step="0.01"  value={formData.valor} name="valor" onChange={handleChange} width={'50%'} required> 
                        </Input>

                        <Text>
                            Imagens
                        </Text>
                        <Input
                            type="file"
                            multiple
                            onChange={handleFileChange}
                        />

                    </ContentInputs>
                    <ContentPhotos>
                        {arquivos.map((foto, index) => {
                            const fotoUrl = URL.createObjectURL(foto);
                            return(
                                <CelulaPhoto key={index}>
                                    <img
                                        src={fotoUrl}
                                        alt={`Preview ${index}`}
                                    />
                                    <ButtonDelete onClick={() => handleRemove(index)}>
                                        <FaTrash size={20} color="#ff0000" />
                                    </ButtonDelete>
                                </CelulaPhoto>
                            )
                        })}
                    </ContentPhotos>
                </ContentAtributos>
                <Button type="submit">
                    {buttonTitle}
                </Button>
            </Content>
        </Container>
    )
}

export default CadastrarProduto;