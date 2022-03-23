import { useEffect } from 'react';

const useBlazor = () => {
  useEffect(() => {
    const script = document.createElement('script');

    script.src = '/_framework/blazor.webassembly.js';

    document.body.appendChild(script);

    return () => {
      document.body.removeChild(script);
    }      
  });
};

export default useBlazor;