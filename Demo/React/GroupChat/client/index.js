import React from 'react';
import dotnetify from 'dotnetify';
import ReactDOM from 'react-dom';

import App from './App';
import ChatRoomIndex from './ChatRoomIndex';
import ChatRoomList from './ChatRoomList';
import ChatRoom from './ChatRoom';

dotnetify.debug = true;

// Set the components to global window to make it accessible to dotNetify routing.
Object.assign(window, { ChatRoomIndex, ChatRoom, ChatRoomList });

ReactDOM.render(<App />, document.getElementById('App'));
