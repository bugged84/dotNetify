import React from 'react';
import { RouteLink } from 'dotnetify/dist/dotnetify-react';

const ChatRoomList = ({ vm, chatRooms }) => {
    const chatRoomLinks =
        chatRooms
        &&
        chatRooms.map(
            chatRoom => (
                <RouteLink
                    vm={vm}
                    route={chatRoom.Route}
                    key={chatRoom.Id}
                >
                    <div>Chat Room {chatRoom.Id}</div>
                </RouteLink>
            )
        );

    return <div>{chatRoomLinks}</div>;
};

export default ChatRoomList;