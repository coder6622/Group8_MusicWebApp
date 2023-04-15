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

export { GetSongs as getSongs };
