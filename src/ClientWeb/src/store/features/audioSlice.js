import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  isPlay: true,
  isMute: false,
  songId: localStorage.getItem('songId') || '',
  currentIndexPlaylist: 0,
  infoSongPlayer: {
    name: '',
    imageUrl: '',
    artistsName: '',
    artists: [],
  },
  songUrl: '',
  currentTime: 0,
  duration: 0,
  volume: Number(localStorage.getItem('volume')) || 0.5,
  isLoop: false,
  autoPlay: false,
  playlistSong: [],
  showLyric: false,
  lyrics: '',
};

const audioSlice = createSlice({
  name: 'songPlayer',
  initialState,
  reducers: {
    changeIconPlay: (state, action) => {
      state.isPlay = action.payload;
    },
    changeIconVolume: (state, action) => {
      state.isMute = action.payload;
    },
    setSongId: (state, action) => {
      localStorage.setItem('songId', action.payload);
      state.songId = action.payload;
    },
    setInfoSongPlayer: (state, action) => {
      console.log(state);
      state.infoSongPlayer = {
        ...state.infoSongPlayer,
        ...action.payload,
      };
    },
    setSrcAudio: (state, action) => {
      state.songUrl = action.payload;
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
      state.showLyric = action.payload;
    },
    setLyric: (state, action) => {
      state.lyrics = action.payload;
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
  setLyric,
} = audioSlice.actions;

export const audioSliceReducer = audioSlice.reducer;
