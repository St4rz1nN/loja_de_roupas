import { Container, ContentModal, Text, Button, Spinner } from './styles.js'


const Modal = ( { Height, Width, Tipo, Mensagem, Visivel, TextTamanho, OnClick }) => {
    if(Tipo == "Alerta"){
        return(
            <Container Visivel={Visivel}>
                <ContentModal Visivel={Visivel} Height={Height} Width={Width}  background="white" boxshadow={true}>
                    <Text Height={70} TextTamanho={TextTamanho}>
                        {Mensagem}
                    </Text>

                    <Button Height={Height} onClick={OnClick}>
                        Confirmar
                    </Button>
                </ContentModal>
            </Container>
        )
    } else if(Tipo == "Carregando"){
        return(
            <Container Visivel={Visivel}>
                <ContentModal Visivel={Visivel} Height={Height} Width={Width} background="transparent" boxshadow={false}>
                    <Text TextTamanho={TextTamanho} Height={100}>
                        <Spinner></Spinner>
                    </Text>
                </ContentModal>
            </Container>
        )
    }
}

export default Modal;