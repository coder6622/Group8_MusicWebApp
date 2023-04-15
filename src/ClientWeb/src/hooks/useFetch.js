import { useEffect, useState } from 'react';
import http from '../http-common';

const useFetch = () => {
  const [response, setResponse] = useState({
    items: [],
    metadata: {},
  });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(true);
  const [controller, setController] = useState(0);

  async function axiosFetchAsync(params) {
    console.log('fetch');
    try {
      setLoading(true);
      setController(new AbortController());
      const response = await http.request(params);

      const data = response.data;
      if (data.isSuccess) {
        setResponse(data.result);
      } else
        setResponse({
          items: [],
          metadata: {},
        });
    } catch (error) {
      setError(error);
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    return () => controller && controller.abort();
  }, [controller]);

  return { response, error, loading, axiosFetchAsync };
};

export default useFetch;
