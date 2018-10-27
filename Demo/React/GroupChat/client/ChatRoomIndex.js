import React from 'react';
import dotnetify from 'dotnetify';
import { RouteLink } from 'dotnetify/dist/dotnetify-react';

class ChatRoomIndex extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            ChatRooms: [],
            lobby: true
        };

        this.vm = dotnetify.react.connect('ChatRoomIndexVM', this);

        this.vm.onRouteEnter = (path, template) => {
            console.log(path);
            console.log(template);
            template.Target = 'Content2';
            this.setState({ lobby: template.Id === 'Lobby' });
        };
    }

    componentWillUnmount() {
        this.vm.$destroy();
    }

    render() {
        const chatRooms = this.state.ChatRooms.map(
            chatRoom => (
                <RouteLink vm={this.vm} route={chatRoom.Route} key={chatRoom.Id}>
                    <div>Chat Room {chatRoom.Id}</div>
                </RouteLink>
            )
        );

        return (
            <div>
                {this.state.lobby && <div>{chatRooms}</div>}
                <div id="Content2" />
            </div>
        );
    }
}

const Lobby = () => <div />;

export { Lobby };
export default ChatRoomIndex;