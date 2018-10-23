import React from 'react';
import dotnetify from 'dotnetify';

class ChatRoom extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            Name: ""
        };

        this.vm = dotnetify.react.connect('ChatRoomVM', this);
    }

    componentWillUnmount() {
        this.vm.$destroy();
    }

    render() {
        return (
            <div>
                {this.state.Name}
            </div>
        );
    }
}

export default ChatRoom;