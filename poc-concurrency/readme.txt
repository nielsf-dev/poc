om dus ssl requests te maken:

            TrustManager[] trustManagers = new TrustManager[] { new X509TrustManager() {
                public java.security.cert.X509Certificate[] getAcceptedIssuers() {
                    logger.trace("getting acccepted issures");
                    return null;
                }
                public void checkClientTrusted(X509Certificate[] certs, String authType) {
                    logger.trace("checkClientTrusted");
                }
                public void checkServerTrusted(X509Certificate[] certs, String authType) {
                    logger.trace("checkServerTrusted");
                }
            } };

            SSLContext sslContext = SSLContext.getInstance("SSL");
            sslContext.init(null, trustManagers, new SecureRandom());

            SSLParameters sslParameters = new SSLParameters();
            // This should prevent host validation
            sslParameters.setEndpointIdentificationAlgorithm("");

            HttpClient client = HttpClient.newBuilder()
                    .version(HttpClient.Version.HTTP_1_1)
                    .sslParameters(sslParameters)
                    .sslContext(sslContext)
                    .build();