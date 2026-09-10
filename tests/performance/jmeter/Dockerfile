FROM eclipse-temurin:17-jre-jammy

ARG JMETER_VERSION=5.6.3
RUN apt-get update \
    && apt-get install -y --no-install-recommends ca-certificates curl \
    && curl --fail --location --retry 3 \
      "https://archive.apache.org/dist/jmeter/binaries/apache-jmeter-${JMETER_VERSION}.tgz" \
      --output /tmp/jmeter.tgz \
    && tar -xzf /tmp/jmeter.tgz -C /opt \
    && ln -s "/opt/apache-jmeter-${JMETER_VERSION}/bin/jmeter" /usr/local/bin/jmeter \
    && rm -rf /var/lib/apt/lists/* /tmp/jmeter.tgz

WORKDIR /plans
ENTRYPOINT ["jmeter"]