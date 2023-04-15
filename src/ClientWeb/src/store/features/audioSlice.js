import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  isPlay: false,
  isMute: false,
  songId: localStorage.getItem('songId') || '',
  currentIndexPlaylist: 0,
  infoSongPlayer: {
    title: '',
    thumbnail: '',
    artistsNames: '',
    artists: [],
  },
  srcAudio: '',
  currentTime: 0,
  duration: 0,
  volume: Number(localStorage.getItem('volume')) || 0.5,
  isLoop: false,
  autoPlay: false,
  playlistSong: [],
  isLyric: false,
};

const audioSlice = createSlice({
  name: 'audio',
  initialState,
  reducers: {
    changeIconPlay: (state, action) => {
      state.isPlay = action.payload;
    },
    changeIconVolume: (state, action) => {
      state.isMute = action.payload;
    },
    setSongId: (state, action) => {
      state.songId = action.payload;
      localStorage.setItem('songId', action.payload);
    },
    setInfoSongPlayer: (state, action) => {
      state.infoSongPlayer = {
        ...state.infoSongPlayer,
        ...action.payload,
      };
    },
    setSrcAudio: (state, action) => {
      state.srcAudio = action.payload;
    },
    setCurrentTime: (state, action) => {
      state.currentTime = action.payload;
    },
    setDuration: (state, action) => {
      state.duration = action.payload;
    },
    setVolume: (state, action) => {
      state.volume = action.payload;
    },
    setLoop: (state, action) => {
      state.isLoop = action.payload;
    },
    setAutoPlay: (state, action) => {
      state.autoPlay = action.payload;
    },
    setPlaylistSong: (state, action) => {
      state.playlistSong = action.payload;
    },
    setCurrnetIndexPlaylist: (state, action) => {
      state.currnetIndexPlaylist = action.payload;
    },
    setOpenLyric: (state, action) => {
      state.isLyric = action.payload;
    },
  },
});

export const {
  changeIconPlay,
  changeIconVolume,
  setSongId,
  setInfoSongPlayer,
  setCurrentTime,
  setDuration,
  setVolume,
  setLoop,
  setSrcAudio,
  setAutoPlay,
  setPlaylistSong,
  setCurrnetIndexPlaylist,
  setOpenLyric,
} = audioSlice.actions;

export const audioSliceReducer = audioSlice.reducer;
