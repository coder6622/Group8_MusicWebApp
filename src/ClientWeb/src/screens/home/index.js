import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Sidebar from '../../components/sidebar';
import Feed from '../feed';
import Trending from '../trending';
import Player from '../player';
import Favorites from '../favorites';
import Playlist from '../library';
import './home.css';

export default function Home() {
  return (
    <Router>
      <div className='main-body'>
        <Sidebar />
        <Routes>
          <Route
            path='/'
            element={<Playlist />}
          />
          <Route
            path='/feed'
            element={<Feed />}
          />
          <Route
            path='/rending'
            element={<Trending />}
          />
          <Route
            path='/player'
            element={<Player />}
          />
          <Route
            path='/favorites'
            element={<Favorites />}
          />
        </Routes>
      </div>
    </Router>
  );
}
