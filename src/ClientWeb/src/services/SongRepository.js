import config from '../config';
import useFetch from '../hooks/useFetch';
import http from '../http-common';

async function GetSongs(params) {
  return useFetch({
    method: 'get',
    url: config.endpoints.songs,
    params: params,
  });
}

export const getSongPlayer = (id) => {
  return {
    method: 'get',
    url: config.endpoints.songs + `/${id}`,
  };
};

export { GetSongs as getSongs };
