async function calculateAndRender() {
    const line1 = { x1: 1, y1: 1, x2: 4, y2: 4 };
    const line2 = { x3: 1, y3: 4, x4: 4, y4: 1 };

    const intersectionResponse = await fetch('http://localhost:5013/api/FindIntersection', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ ...line1, ...line2 }),
    });

    if (!intersectionResponse.ok) {
        throw new Error('Помилка при розрахунку точки перетину.');
    }

    const intersection = await intersectionResponse.json();
    const x = intersection.x;
    const y = intersection.y

    const graphResponse = await fetch('http://localhost:5218/api/RenderGraph', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ ...line1, ...line2, px: x, py: y }),
    });

    if (!graphResponse.ok) {
        throw new Error('Помилка при побудові графіка.');
    }

    const svg = await graphResponse.text();
    console.log('SVG:', svg);

    const svgElement = new DOMParser().parseFromString(svg, 'image/svg+xml').documentElement;

    document.getElementById('graph').appendChild(svgElement);
}

calculateAndRender();